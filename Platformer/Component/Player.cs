using Microsoft.Xna.Framework;
using Nez.Sprites;
using Microsoft.Xna.Framework.Input;
using Nez.Tiled;
using Nez;

namespace Platformer
{
    public class Player : Component, ITriggerListener, IUpdatable
    {
        public float MoveSpeed = 150;
        public float Gravity = 1000;
        public float JumpHeight = 16 * 5;

        SpriteAnimator _animator;
        TiledMapMover _mover;
        BoxCollider _boxCollider;
        TiledMapMover.CollisionState _collisionState = new TiledMapMover.CollisionState();
        Vector2 _velocity;

        VirtualButton _jumpInput;
        VirtualIntegerAxis _xAxisInput;


        public override void OnAddedToEntity()
        {
            var texture = Entity.Scene.Content.LoadSpriteAtlas("Content/Assets/Player/Player.atlas");

            _boxCollider = Entity.GetComponent<BoxCollider>();
            _mover = Entity.GetComponent<TiledMapMover>();
            _animator = Entity.AddComponent(new SpriteAnimator()) ;
            _animator.AddAnimationsFromAtlas(texture);
            _animator.Speed = 0.7f;
            _animator.Play("idle");
            SetupInput();
        }

        public override void OnRemovedFromEntity()
        {
            // deregister virtual input
            _jumpInput.Deregister();
            _xAxisInput.Deregister();
        }

        void SetupInput()
        {
            // setup input for jumping. we will allow z on the keyboard or a on the gamepad
            _jumpInput = new VirtualButton();
            _jumpInput.Nodes.Add(new VirtualButton.KeyboardKey(Keys.Z));
            _jumpInput.Nodes.Add(new VirtualButton.GamePadButton(0, Buttons.A));

            // horizontal input from dpad, left stick or keyboard left/right
            _xAxisInput = new VirtualIntegerAxis();
            _xAxisInput.Nodes.Add(new VirtualAxis.GamePadDpadLeftRight());
            _xAxisInput.Nodes.Add(new VirtualAxis.GamePadLeftStickX());
            _xAxisInput.Nodes.Add(new VirtualAxis.KeyboardKeys(VirtualInput.OverlapBehavior.TakeNewer, Keys.Left, Keys.Right));
        }

        void IUpdatable.Update()
        {
            // handle movement and animations
            var moveDir = new Vector2(_xAxisInput.Value, 0);
            string animation = null;

            if (moveDir.X < 0)
            {
                if (_collisionState.Below)
                    animation = "running";
                _animator.FlipX = true;
                _velocity.X = -MoveSpeed;
            }
            else if (moveDir.X > 0)
            {
                if (_collisionState.Below)
                    animation = "running";
                _animator.FlipX = false;
                _velocity.X = MoveSpeed;
            }
            else
            {
                _velocity.X = 0;
                if (_collisionState.Below)
                    animation = "idle";
            }

            if(_collisionState.Above)
            {
                _velocity.Y = 0;
            }

            if (_collisionState.Below && _jumpInput.IsPressed)
            {
                animation = "jump";
                _velocity.Y = -Mathf.Sqrt(2f * JumpHeight * Gravity);
            }

            if(!_collisionState.Below && _velocity.Y >= 0) {
                animation = "fall";
                // apply gravity
            }
            _velocity.Y += Gravity * Time.DeltaTime;

            // move
            _mover.Move(_velocity * Time.DeltaTime, _boxCollider, _collisionState);

            if (_collisionState.Below)
                _velocity.Y = 0;

            if (animation != null && !_animator.IsAnimationActive(animation))
                _animator.Play(animation);
        }

        #region ITriggerListener implementation

        void ITriggerListener.OnTriggerEnter(Collider other, Collider self)
        {
            Debug.Log("triggerEnter: {0}", other.Entity.Name);
        }

        void ITriggerListener.OnTriggerExit(Collider other, Collider self)
        {
            Debug.Log("triggerExit: {0}", other.Entity.Name);
        }

        #endregion
    }
}