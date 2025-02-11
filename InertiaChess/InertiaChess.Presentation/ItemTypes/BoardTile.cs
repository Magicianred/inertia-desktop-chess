﻿using InertiaChess.Presentation.Enums;
using Prism.Commands;
using Prism.Mvvm;
using System.Windows.Input;
using System.Windows.Media;

namespace InertiaChess.Presentation.ItemTypes
{
    public delegate void TilePressed(BoardTile pressedTile);

    public class BoardTile : BindableBase
    {
        public event TilePressed TilePressedEvent;

        private readonly Brush lightColor = new SolidColorBrush(Color.FromRgb(232, 235, 239));
        private readonly Brush darkColor = new SolidColorBrush(Color.FromRgb(125, 135, 150));
        private readonly Brush lightSelectionColor = new SolidColorBrush(Color.FromRgb(242, 255, 219));
        private readonly Brush darkSelectionColor = new SolidColorBrush(Color.FromRgb(135, 155, 130));

        private Brush tileColor;
        private Brush selectionColor;
        private bool isTileSelected;

        public BoardTile(TileType tileType)
        {
            this.TileColor = tileType == TileType.Light ? lightColor : darkColor;
            this.SelectionColor = tileType == TileType.Light ? lightSelectionColor : darkSelectionColor;

            this.TilePressedCommand = new DelegateCommand(this.OnTilePressed);
        }

        public ICommand TilePressedCommand { get; }

        public Brush TileColor 
        {
            get => this.tileColor;
            set => this.SetProperty(ref this.tileColor, value);
        }

        public Brush SelectionColor 
        {
            get => this.selectionColor;
            set => this.SetProperty(ref this.selectionColor, value);
        }

        public bool IsTileSelected
        {
            get => this.isTileSelected;
            set => this.SetProperty(ref this.isTileSelected, value);
        }

        private void OnTilePressed()
        {
            this.IsTileSelected = true;
            this.TilePressedEvent?.Invoke(this);
        }
    }
}
