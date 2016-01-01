namespace Masterbot {
    public class Role : WrapDiscord<Discord.Role> {
        public Role(ChatClient client, Discord.Role inner): base(client, inner) {}
    }
}