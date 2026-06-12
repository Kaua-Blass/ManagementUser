using System.ComponentModel.DataAnnotations;

namespace ManagementUser.DTOs;

public static class PerfilDto
{
    // --- Para POST (Criação) ---
    public class PerfilCreateRequest
    {
        [Required(ErrorMessage = "Nome do perfil é obrigatório!")]
        [StringLength(50)]
        public required string Nome { get; set; }

        [StringLength(200)]
        public string? Descricao { get; set; }
    }

    // --- Para PUT (Atualização) ---
    public class PerfilUpdateRequest
    {
        [Required(ErrorMessage = "ID do perfil é obrigatório!")]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public required string Nome { get; set; }

        [StringLength(200)]
        public string? Descricao { get; set; }
    }

    // --- Para GET (Resposta) ---
    public class PerfilResponse
    {
        public int Id { get; set; }

        public required string Nome { get; set; }

        public string? Descricao { get; set; }

        // Lista simplificada de usuários
        public List<UserShortResponse> Usuarios { get; set; } = new();
    }

    // --- DTO auxiliar para evitar referência circular ---
    public class UserShortResponse
    {
        public int Id { get; set; }

        public required string Nome { get; set; }

        public required string Email { get; set; }
    }
}