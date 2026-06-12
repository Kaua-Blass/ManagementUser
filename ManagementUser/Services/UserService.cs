using ManagementUser.Data;
using ManagementUser.DTOs;
using ManagementUser.Models;
using Microsoft.EntityFrameworkCore;

namespace ManagementUser.Services;

public class UserService
{
    private readonly AppDbContext _context;

    public UserService(AppDbContext context)
    {
        _context = context;
    }

    // Método para criar usuário
    public async Task<UserDto.UserResponse> CreateUser(UserDto.UserCreateRequest dto)
    {
        // Validação: email único
        if (await _context.Users.AnyAsync(u => u.Email == dto.Email))
            throw new Exception("Email já cadastrado!");

        // Mapear DTO para entidade
        var user = new User
        {
            Nome = dto.Nome,
            Email = dto.Email,
            SenhaHash = BCrypt.Net.BCrypt.HashPassword(dto.Senha),
            DataCriacao = DateTime.UtcNow
        };

        // Salvar no banco
        _context.Users.Add(user);
        await _context.SaveChangesAsync();

        // Retornar DTO de resposta
        return new UserDto.UserResponse
        {
            Id = user.Id,
            Nome = user.Nome,
            Email = user.Email,
            DataCriacao = user.DataCriacao,
            PerfilId = user.PerfilId
        };
    }

    // Buscar usuário por ID
    public async Task<UserDto.UserResponse?> GetUserById(int id)
    {
        // Busca o usuário incluindo o perfil relacionado
        var user = await _context.Users
            .Include(u => u.Perfil)
            .FirstOrDefaultAsync(u => u.Id == id);

        if (user == null)
            return null;

        // Mapear entidade para DTO
        return new UserDto.UserResponse
        {
            Id = user.Id,
            Nome = user.Nome,
            Email = user.Email,
            DataCriacao = user.DataCriacao,
            PerfilId = user.PerfilId
        };
    }

    // Outros métodos (Update, Delete...)
}