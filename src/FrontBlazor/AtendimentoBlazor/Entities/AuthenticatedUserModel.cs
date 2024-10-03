namespace AtendimentoBlazor.Entities
{
    public sealed class AuthenticatedUserModel
    {
        public string Access_Token { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
    }
}
