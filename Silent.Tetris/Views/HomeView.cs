﻿using System;
using Silent.Tetris.Contracts;
using Silent.Tetris.Contracts.Presenters;
using Silent.Tetris.Presenters;

namespace Silent.Tetris.Views
{
    public class HomeView : ViewBase<IHomePresenter>
    {
        public HomeView() : base(
            new[]
            {
                MenuOptions.StartGame,
                MenuOptions.HighScores,
                MenuOptions.Exit
            })
        {
        }

        public override void Initialize(INavigationService navigationService)
        {
            NavigationService = navigationService;
            Presenter = new HomePresenter(this);
            Presenter.Initialize();
        }

        public override void Render()
        {
            Console.Clear();

            int centerX = Console.WindowWidth / 2;
            int centerY = Console.WindowHeight / 2;

            for (int index = 0; index < Options.Length; index++)
            {
                string formattedOption;
                MenuOptions currentOption = Options[index];

                if (currentOption == Options[MenuOptionIndex])
                {
                    formattedOption = $"- {currentOption} -";
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                }
                else
                {
                    formattedOption = currentOption.ToString();
                }

                int textStartPositionX = centerX - formattedOption.Length / 2 - 1;
                int textStartPositionY = centerY - Options.Length / 2 + index;

                Console.SetCursorPosition(textStartPositionX, textStartPositionY);
                Console.Write(formattedOption);
                Console.ResetColor();
            }
        }
    }
}