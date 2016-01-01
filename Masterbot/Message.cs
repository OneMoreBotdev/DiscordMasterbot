namespace Masterbot {
    public class Message : WrapDiscord<Discord.Message> {
        public Message(ChatClient client, Discord.Message inner): base(client, inner) {}
    }
}