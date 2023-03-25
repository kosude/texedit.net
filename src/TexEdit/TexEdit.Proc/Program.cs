/*
 *   Copyright (c) 2023 Jack Bennett
 *   All rights reserved.
 *
 *   Please see the LICENCE file for more information.
 */

using Avalonia;
using Avalonia.ReactiveUI;

using TexEdit.UI;

namespace TexEdit.Proc {
    public class Program {
        [STAThread]
        public static void Main(string[] args) {
            BuildAvaloniaApp().StartWithClassicDesktopLifetime(args);
        }

        public static AppBuilder BuildAvaloniaApp() {
            return AppBuilder.Configure<UIApplication>()
                .UsePlatformDetect()
                .LogToTrace()
                .UseReactiveUI();
        }
    }
}
