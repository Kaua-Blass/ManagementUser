namespace ManagementUser.Models;

public class Perfil
{
    public int Id { get; set; }

    // Ex: "Admin", "Cliente", "Gerente"
    public required string Nome { get; set; }

    public string? Descricao { get; set; }

    // Relacionamento: Um perfil pode ter vários usuários
    public List<User> Usuarios { get; set; } = new();
}