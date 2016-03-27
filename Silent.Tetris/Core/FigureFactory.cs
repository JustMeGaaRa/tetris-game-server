using System.Collections.Generic;
using Silent.Tetris.Contracts;
using Silent.Tetris.Core.Sprites;

namespace Silent.Tetris.Core
{
    public class FigureFactory : IFactory<FigureBase>
    {
        public IEnumerable<FigureBase> Create()
        {
            yield return new FigureI();
            yield return new FigureL();
            yield return new FigureX();
            yield return new FigureD();
            yield return new FigureS();
            yield return new FigureT();
            yield return new FigureZ();
        }
    }
}