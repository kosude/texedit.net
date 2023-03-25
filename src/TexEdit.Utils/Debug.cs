/*
 *   Copyright (c) 2023 Jack Bennett
 *   All rights reserved.
 *
 *   Please see the LICENCE file for more information.
 */

namespace TexEdit.Utils {
    /// <summary>
    /// Debug utility functions
    /// </summary>
    public class Debug {
        /// <summary>
        /// Output a debug message to console.
        /// </summary>
        /// <param name="str">Printed string</param>
        public static void Log(string str) {
            Console.WriteLine($"texedit: LOG  : {str}");
        }

        /// <summary>
        /// Output a notification to console.
        /// </summary>
        /// <param name="str">Printed string</param>
        public static void Notification(string str) {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"texedit: NOTE : {str}");
            Console.ResetColor();
        }

        /// <summary>
        /// Output a warning to console.
        /// </summary>
        /// <param name="str">Printed string</param>
        public static void Warning(string str) {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"texedit: WARN : {str}");
            Console.ResetColor();
        }

        /// <summary>
        /// Output an error to console.
        /// </summary>
        /// <param name="str">Printed string</param>
        public static void Error(string str) {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"texedit: ERROR: {str}");
            Console.ResetColor();
        }

        /// <summary>
        /// Output a fatal error to console.
        /// </summary>
        /// <param name="str">Printed string</param>
        public static void FatalError(string str) {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"texedit: FATAL: {str}");
            Console.ResetColor();

            Environment.Exit(1);
        }
    }
}
