using Silent.Tetris.Contracts.Core;

namespace Silent.Tetris.Contracts.Views
{
    /// <summary>
    /// Represents the view.
    /// </summary>
    public interface IView
    {
        /// <summary>
        /// Getes the size of the view.
        /// </summary>
        Size Size { get; }

        /// <summary>
        /// Initializes the view and its components.
        /// </summary>
        void Initialize();

        /// <summary>
        /// Performs rendering of curent view.
        /// </summary>
        void Render();
    }

    /// <summary>
    /// Represents the view with its presenter.
    /// </summary>
    /// <typeparam name="TPresenter"> The concrete presenter type. </typeparam>
    public interface IView<out TPresenter> : IView
    {
        /// <summary>
        /// Gets the presenter instance for current view.
        /// </summary>
        TPresenter Presenter { get; }
    }
}