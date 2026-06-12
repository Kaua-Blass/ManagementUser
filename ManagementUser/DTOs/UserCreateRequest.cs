using System.ComponentModel.DataAnnotations;

namespace ManagementUser.DTOs;

public static class UserDto
{
    // --- Para POST (Criação) ---
    public class UserCreateRequest
    {
        [Required(ErrorMessage = "Nome é obrigatório!")]
        [StringLength(100, MinimumLength = 3)]
        public required string Nome { get; set; }

        [Required(ErrorMessage = "Email é obrigatório!")]
        [EmailAddress(ErrorMessage = "Formato de email inválido!")]
        public required string Email { get; set; }

        [Required(ErrorMessage = "Senha é obrigatória!")]
        [MinLength(6, ErrorMessage = "Senha deve ter no mínimo 6 caracteres!")]
        public required string Senha { get; set; } // Será hasheada no serviço
    }

    // --- Para PUT (Atualização) ---
    public class UserUpdateRequest
    {
        [Required(ErrorMessage = "ID do usuário é obrigatório!")]
        public int Id { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 3)]
        public required string Nome { get; set; }

        [Required]
        [EmailAddress]
        public required string Email { get; set; }
    }

    // --- Para GET (Resposta) ---
    public class UserResponse
    {
        public int Id { get; set; }

        public required string Nome { get; set; }

        public required string Email { get; set; }

        public DateTime DataCriacao { get; set; }

        // Apenas o ID para evitar referência circular
        public int PerfilId { get; set; }
    }
}