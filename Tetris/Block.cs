namespace Tetris
{
    internal abstract class Block
    {
        protected abstract Position[][] Tiles { get; }
        protected abstract Position StartOffset { get; }
        protected abstract EBlock block { get; }

        private ERotationState rotationState;
        private Position offset;

        public Block()
        {
            rotationState = ERotationState.Rotation_0;
            offset = new Position(StartOffset.Row, StartOffset.Column);
        }

        public void RotateCW()
        {
            rotationState = (ERotationState)(((int)rotationState + 1) % Tiles.Length);
        }

        public void RotateCCW()
        {
            if (rotationState == ERotationState.Rotation_0)
            {
                rotationState = ERotationState.Rotation_270;
            }
            else
            {
                rotationState = (ERotationState)((int)rotationState--);
            }
        }

        public void Move(int rows, int columns)
        {
            offset.Row += rows;
            offset.Column += columns;
        }

        public void Reset()
        {
            rotationState = ERotationState.Rotation_0;
            offset.Row = StartOffset.Row;
            offset.Column = StartOffset.Column; 
        }
    }
}
