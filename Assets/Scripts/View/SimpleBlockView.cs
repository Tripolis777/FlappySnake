using UnityEngine;
using UnityEngine.Assertions;

using SomeAnyBird.Model;

namespace SomeAnyBird.View
{
    public class SimpleBlockView : BlockView
    {
        [SerializeField] protected GameObject _bottomWall;
        [SerializeField] protected GameObject _topWall;
        [SerializeField] protected Transform _passTrigger;

        #region Unity

        private void OnValidate()
        {
            Assert.IsNotNull(_bottomWall);
            Assert.IsNotNull(_topWall);
            Assert.IsNotNull(_passTrigger);
        }

        #endregion
        
        public override void Move(float x, float y)
        {
            var newPosition = transform.position + new Vector3(x * Time.deltaTime, y, 0);
            transform.position = newPosition;
        }
        
        public override void UpdateState(BlockModel model)
        {
            UpdatePosition(model);
            UpdateBlockPass(model);
            UpdatePassTrigger(model);
        }

        private void UpdateBlockPass(BlockModel model)
        {
            var wallDistance = model.Pass.Value / 2.0f;

            var bottomWallPosition = _bottomWall.transform.localPosition;
            var topWallPosition = _topWall.transform.localPosition;

            bottomWallPosition.y = -wallDistance;
            topWallPosition.y = wallDistance;

            _bottomWall.transform.localPosition = bottomWallPosition;
            _topWall.transform.localPosition = topWallPosition;
        }

        private void UpdatePosition(BlockModel model)
        {
            var position = transform.position;
            position.y = model.Position.Value;
            transform.position = position;
        }

        private void UpdatePassTrigger(BlockModel model)
        {
            var scale = _passTrigger.localScale;
            scale.y = model.Pass.Value;
            _passTrigger.localScale = scale;
        }
        
    }
}