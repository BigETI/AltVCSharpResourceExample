using AltV.Net;
using AltV.Net.Elements.Entities;
using AltVCSharpResourceExample.Factories;

/// <summary>
/// alt:V C♯ Resource Example resources namespace
/// </summary>
namespace AltVCSharpResourceExample.Resources
{
    /// <summary>
    /// Example resource class
    /// </summary>
    internal class ExampleResource : Resource
    {
        /// <summary>
        /// On resource started event
        /// </summary>
        public override void OnStart()
        {
            // ...
        }

        /// <summary>
        /// On resource stopped event
        /// </summary>
        public override void OnStop()
        {
            // ...
        }

        /// <summary>
        /// Get blip factory
        /// </summary>
        /// <returns>Blip factory</returns>
        public override IBaseObjectFactory<IBlip> GetBlipFactory() => new ExampleBlipFactory();

        /// <summary>
        /// Get checkpoint factory
        /// </summary>
        /// <returns>Checkpoint factory</returns>
        public override IBaseObjectFactory<ICheckpoint> GetCheckpointFactory() => new ExampleCheckpointFactory();

        /// <summary>
        /// Get collideable shape factory
        /// </summary>
        /// <returns>Collideable shape factory</returns>
        public override IBaseObjectFactory<IColShape> GetColShapeFactory() => new ExampleCollideableShapeFactory();

        /// <summary>
        /// Get player factory
        /// </summary>
        /// <returns>Player factory</returns>
        public override IEntityFactory<IPlayer> GetPlayerFactory() => new ExamplePlayerFactory();

        /// <summary>
        /// Get vehicle factory
        /// </summary>
        /// <returns>Vehicle factory</returns>
        public override IEntityFactory<IVehicle> GetVehicleFactory() => new ExampleVehicleFactory();
    }
}
