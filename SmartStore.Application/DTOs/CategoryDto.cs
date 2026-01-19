namespace SmartStore.Application.DTOs;

public record CategoryDto (
    int Id,
    string Name,
    bool IsActive
);
