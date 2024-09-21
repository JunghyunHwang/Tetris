namespace Tetris
{
    internal sealed class OBlock : Block
    {
        private readonly Position[][] tiles = new Position[][]
        {
            new Position[] { new Position(0, 0), new Position(0, 1), new Position(1, 0), new Position(1, 1) },
        };

        protected override Position[][] Tiles => tiles;
        protected override Position StartOffset => new Position(0, 4);
        protected override EBlock block => EBlock.O;
    }
}
