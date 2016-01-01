namespace Masterbot {
    public class User : WrapDiscord<Discord.User> {
        public User(ChatClient client, Discord.User inner): base(client, inner) {}
    }
}