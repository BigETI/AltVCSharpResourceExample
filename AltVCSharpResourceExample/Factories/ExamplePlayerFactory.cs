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
    /// Example player factory class
    /// </summary>
    internal class ExamplePlayerFactory : IEntityFactory<IPlayer>
    {
        /// <summary>
        /// Create player
        /// </summary>
        /// <param name="entityPointer">Entity pointer</param>
        /// <param name="id">Player entity ID</param>
        /// <returns>Player</returns>
        public IPlayer Create(IntPtr entityPointer, ushort id) => new ExamplePlayerEntity(entityPointer, id);
    }
}
