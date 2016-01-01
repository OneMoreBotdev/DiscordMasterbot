namespace Masterbot {
    public class PermissionOverwrite {
        private Discord.Channel.PermissionOverwrite _inner;

        public PermissionOverwrite(Discord.Channel.PermissionOverwrite permission) {
            _inner = permission;
        }
    }
}