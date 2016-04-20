using System;

namespace TempName
{
    class Errors
    {
        public static string MasterServerNotConnetMessage { get; } = String.Format("=== Cannot Reach Master Server ===");

        public static string HostNotConnetMessage { get; } = String.Format("======= Cannot Reach Host! =======");

        public static string PasswordServerMessage { get; } = String.Format("=========== Passworded! ==========");

        public static string NoPlayersFoundMessage { get; } = String.Format("========= Server Empty! ==========");

        public static string FullServerMessage { get; } = String.Format("========== Server Full! ==========");

        public static string PlayerHasNoNameMessage { get; } = String.Format("======= Player has no name! ======");

        public static string PlayerHasNoUIDMessage { get; } = String.Format("======= Player has no uid! =======");
    }
}
