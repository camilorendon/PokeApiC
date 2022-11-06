using System;
using System.Collections.Generic;

namespace pokeApi.Models;

public partial class Registro
{
    public int IdRegistro { get; set; }

    public string? Nombre { get; set; }

    public string? Apellido { get; set; }

    public string? Correo { get; set; }

    public byte[] Contraseña { get; set; } = null!;

    public virtual Usuario IdRegistroNavigation { get; set; } = null!;

    public virtual InicioSesion? InicioSesion { get; set; }
}
