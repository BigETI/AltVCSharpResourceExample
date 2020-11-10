using AltV.Net.Elements.Entities;
using System;

/// <summary>
/// alt:V C♯ Resource Example entities namespace
/// </summary>
namespace AltVCSharpResourceExample.Entities
{
    /// <summary>
    /// Example player entity class
    /// </summary>
    internal class ExamplePlayerEntity : Player, IExamplePlayerEntity
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="nativePointer">Native pointer</param>
        /// <param name="id">Player entity ID</param>
        public ExamplePlayerEntity(IntPtr nativePointer, ushort id) : base(nativePointer, id)
        {
            // ...
        }
    }
}
