using System.Collections.Generic;
using Silent.Tetris.Contracts.Core;
using Silent.Tetris.Extensions;

namespace Silent.Tetris.Core.Engine
{
    public abstract class FieldBase : IField
    {
        private readonly Size _size;
        private Color[,] _cachedGameFieldView;

        protected FieldBase(Size size)
        {
            _size = size;
        }

        public Size Size => _size;

        public ISprite GetView()
        {
            IEnumerable<ISprite> sprites = GetSpriteCollection();
            Color[,] currentGameFieldView = new Color[Size.Height, Size.Width];

            foreach (ISprite sprite in sprites)
            {
                FillColorView(currentGameFieldView, sprite);
            }

            Color[,] differenceGameFieldView = _cachedGameFieldView == null
                ? currentGameFieldView
                : ColorArrayTransformer.GetDifference(_cachedGameFieldView, currentGameFieldView);

            _cachedGameFieldView = currentGameFieldView;

            return CreateFieldSprite(differenceGameFieldView);
        }

        protected abstract IEnumerable<ISprite> GetSpriteCollection();

        protected void FillColorView(Color[,] colorView, ISprite sprite)
        {
            for (int i = 0; i < sprite.Size.Width; i++)
            {
                for (int j = 0; j < sprite.Size.Height; j++)
                {
                    int xPosition = sprite.Position.Left + i;
                    int yPosition = Size.Height - sprite.Position.Bottom - j - 1;

                    if (xPosition >= 0 && 
                        xPosition < colorView.GetLength(1) && 
                        yPosition >= 0 &&
                        yPosition < colorView.GetLength(0) &&
                        sprite[i, j] != Color.Transparent)
                    {
                        colorView[yPosition, xPosition] = sprite[i, j];
                    }
                }
            }
        }

        protected ISprite CreateFieldSprite(Color[,] colors)
        {
            return new FieldSprite(Position.None, colors);
        }

        private class FieldSprite : ISprite
        {
            private readonly Color[,] _colors;

            public FieldSprite(Position position, Color[,] colors)
            {
                _colors = colors;
                Position = position;
                Size = new Size(colors.GetLength(1), colors.GetLength(0));
            }

            public Color this[int x, int y] => _colors[Size.Height - y - 1, x];

            public Position Position { get; }

            public Size Size { get; }
        }
    }
}