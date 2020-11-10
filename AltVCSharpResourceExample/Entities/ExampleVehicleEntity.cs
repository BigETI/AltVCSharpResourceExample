using AltV.Net.Data;
using AltV.Net.Elements.Entities;
using System;

/// <summary>
/// alt:V C♯ Resource Example entities namespace
/// </summary>
namespace AltVCSharpResourceExample.Entities
{
    /// <summary>
    /// Example vehicle entity class
    /// </summary>
    internal class ExampleVehicleEntity : Vehicle, IExampleVehicleEntity
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="model">Vehicle model</param>
        /// <param name="position">Vehicle position</param>
        /// <param name="rotation">Vehicle rotation</param>
        public ExampleVehicleEntity(uint model, Position position, Rotation rotation) : base(model, position, rotation)
        {
            // ...
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="nativePointer">Native pointer</param>
        /// <param name="id">Vehicle entity ID</param>
        public ExampleVehicleEntity(IntPtr nativePointer, ushort id) : base(nativePointer, id)
        {
            // ...
        }
    }
}
