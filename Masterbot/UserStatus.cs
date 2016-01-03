using System;

namespace Masterbot {
    public class UserStatus {
        public static readonly UserStatus Online = new UserStatus(nameof(Online));
        public static readonly UserStatus Idle = new UserStatus(nameof(Idle));
        public static readonly UserStatus Offline = new UserStatus(nameof(Offline));

        private readonly string _name;

        private UserStatus(string name) {
            _name = name;
        }

        public override string ToString() => _name;
    }

    public static class DiscordUserStatusExtensions {
        public static UserStatus Into(this Discord.UserStatus status) {
            if (status == null) {
                return null;
            }
            if (status == Discord.UserStatus.Online) {
                return UserStatus.Online;
            }
            if (status == Discord.UserStatus.Idle) {
                return UserStatus.Idle;
            }
            if (status == Discord.UserStatus.Offline) {
                return UserStatus.Offline;
            }
            throw new ArgumentException("Unknown status to convert: " + status);
        }
    }
}