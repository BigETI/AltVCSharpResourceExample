using AltV.Net;
using AltV.Net.Elements.Entities;
using AltVCSharpResourceExample.Entities;
using System;

/// <summary>
/// alt:V C♯ Resource Example factories namespace
/// </summary>
namespace AltVCSharpResourceExample.Factories
{
    /// <summary>
    /// Example vehicle factory class
    /// </summary>
    internal class ExampleVehicleFactory : IEntityFactory<IVehicle>
    {
        /// <summary>
        /// Create vehicle factory class
        /// </summary>
        /// <param name="entityPointer">Entity pointer</param>
        /// <param name="id">Vehicle entity ID</param>
        /// <returns>Vehicle</returns>
        public IVehicle Create(IntPtr entityPointer, ushort id) => new ExampleVehicleEntity(entityPointer, id);
    }
}
