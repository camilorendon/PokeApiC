using System;
using System.Collections.Generic;

namespace pokeApi.Models;

public partial class InicioSesion
{
    public int IdLogin { get; set; }

    public string? Correo { get; set; }

    public byte[] Contraseña { get; set; } = null!;

    public virtual Registro IdLoginNavigation { get; set; } = null!;
}
