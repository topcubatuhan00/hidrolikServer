﻿namespace Hidrolik.Domain.Models.UserModels;

public class UpdateUserModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string LastName { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Role { get; set; }
    public string UpdaterName { get; set; }
    public bool IsActive { get; set; }
}
