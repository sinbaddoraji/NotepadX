using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace NotepadX
{
    public class Theme : INotifyPropertyChanged
    {
        public static Theme Instance;
        
        public string TextboxBackgroundColorHex { get; set; }
        public string TextboxForegroundColorHex { get; set; }
        public string BackgroundColourHex { get; set;}

        public string MenuBackgroundColorHex { get; set; }

        public string MenuForegroundColorHex { get; set;}

        private FontStyle _fontStyle;
        public FontStyle FontStyle
        {
            get => _fontStyle;
            set
            {
                _fontStyle = value;
                OnPropertyChanged();
            }
        }

        private float _fontSize;
        public float FontSize
        {
            get => _fontSize;
            set
            {
                _fontSize = value;
                OnPropertyChanged();
            }
        }

        private string _fontFamily;

        public string FontFamily
        {
            get => _fontFamily;
            set
            {
                _fontFamily = value;
                OnPropertyChanged();
            }
        }


        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected bool SetField<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }
    }
}
