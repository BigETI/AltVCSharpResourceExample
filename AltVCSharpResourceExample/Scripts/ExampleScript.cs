using AltV.Net;
using AltV.Net.Data;
using AltV.Net.Elements.Args;
using AltV.Net.Elements.Entities;
using AltV.Net.Enums;
using System;
using System.Collections.Generic;

/// <summary>
/// alt:V C♯ Resource Example scripts namespace
/// </summary>
namespace AltVCSharpResourceExample.Scripts
{
    /// <summary>
    /// Example script class
    /// </summary>
    public class ExampleScript : IScript
    {
        /// <summary>
        /// Spawn position
        /// </summary>
        private static readonly Position spawnPosition = new Position(16.008791f, -11.037361f, 70.10693f);

        /// <summary>
        /// SPawn rotation
        /// </summary>
        private static readonly Rotation spawnRotation = new Rotation(0.0f, 0.0f, -0.3957912f);

        /// <summary>
        /// Print value
        /// </summary>
        /// <param name="value">Value</param>
        /// <param name="level">Tab level</param>
        private static void PrintValue(MValueConst value, uint level)
        {
            string tabs = null;
            switch (value.type)
            {
                case MValueConst.Type.None:
                    Console.WriteLine("None");
                    break;
                case MValueConst.Type.Nil:
                    Console.WriteLine("Nil");
                    break;
                case MValueConst.Type.Bool:
                    Console.WriteLine($"\"{ value.GetBool() }\" : \"{ value.type }\"");
                    break;
                case MValueConst.Type.Int:
                    Console.WriteLine($"\"{ value.GetInt() }\" : \"{ value.type }\"");
                    break;
                case MValueConst.Type.Uint:
                    Console.WriteLine($"\"{ value.GetUint() }\" : \"{ value.type }\"");
                    break;
                case MValueConst.Type.Double:
                    Console.WriteLine($"\"{ value.GetDouble() }\" : \"{ value.type }\"");
                    break;
                case MValueConst.Type.String:
                    Console.WriteLine($"\"{ value.GetString() }\" : \"{ value.type }\"");
                    break;
                case MValueConst.Type.List:
                    PrintValues(value.GetList(), level + 1U);
                    break;
                case MValueConst.Type.Dict:
                    tabs ??= new string('\t', (int)level + 1);
                    Console.WriteLine();
                    foreach (KeyValuePair<string, MValueConst> pair in value.GetDictionary())
                    {
                        Console.Write($"{ tabs }Key: \"{ pair.Key }\": ");
                        PrintValue(pair.Value, level + 1U);
                    }
                    break;
                case MValueConst.Type.Entity:
                    Console.WriteLine($"Entity: \"{ value.nativePointer }\" : \"{ value.type }\"");
                    break;
                case MValueConst.Type.Function:
                    Console.WriteLine("Function");
                    break;
                case MValueConst.Type.Vector3:
                    Console.WriteLine($"\"{ value.GetVector3() }\" : \"{ value.type }\"");
                    break;
                case MValueConst.Type.Rgba:
                    Console.WriteLine($"\"{ value.GetRgba() }\" : \"{ value.type }\"");
                    break;
                case MValueConst.Type.ByteArray:
                    tabs ??= new string('\t', (int)level + 1);
                    Console.WriteLine();
                    byte[] bytes = value.GetByteArray();
                    for (int index = 0; index < bytes.Length; index++)
                    {
                        Console.WriteLine($"{ tabs }[{ index }] 0x{ bytes[index]:X2}");
                    }
                    break;
            }
        }

        /// <summary>
        /// Print values
        /// </summary>
        /// <param name="values">Values</param>
        /// <param name="level">Tab level</param>
        private static void PrintValues(IEnumerable<MValueConst> values, uint level = 0U)
        {
            string tabs = new string('\t', (int)level);
            foreach (MValueConst value in values)
            {
                Console.Write(tabs);
                PrintValue(value, level);
            }
        }

        /// <summary>
        /// Checkpoint interacted event
        /// </summary>
        /// <param name="checkpoint">Checkpoint</param>
        /// <param name="entity">Entity</param>
        /// <param name="state">Checkpoint state</param>
        [ScriptEvent(ScriptEventType.Checkpoint)]
        public void CheckpointInteractedEvent(IExampleCheckpointEntity checkpoint, IEntity entity, bool state)
        {
            Console.WriteLine($"Checkpoint was { (state ? "entered" : "left") } by entity ID { entity.Id }.");
        }

        /// <summary>
        /// Collideable shape interacted event
        /// </summary>
        /// <param name="colShape"></param>
        /// <param name="targetEntity"></param>
        /// <param name="state"></param>
        [ScriptEvent(ScriptEventType.ColShape)]
        public void CollideableShapeInteractedEvent(IExampleColleadableShapeEntity colShape, IEntity targetEntity, bool state)
        {
            Console.WriteLine($"Collideable shape at { colShape.Position } was { (state ? "entered" : "left") } by entity ID { targetEntity.Id }.");
        }

        /// <summary>
        /// Console command executed event
        /// </summary>
        /// <param name="name">Command name</param>
        /// <param name="args">Command arguments</param>
        [ScriptEvent(ScriptEventType.ConsoleCommand)]
        public void ConsoleCommandExecutedEvent(string name, string[] args)
        {
            Console.WriteLine($"Command: \"{ name }\"");
            Console.WriteLine("Arguments:");
            foreach (string argument in args)
            {
                Console.WriteLine($"\t{ argument }");
            }
        }

        // ISSUE: Fails to register method
        //[ScriptEvent(ScriptEventType.Explosion)]
        //public bool ExplosionDelegate(IExamplePlayerEntity player, AltV.Net.Data.ExplosionType explosionType, Position position, uint explosionFx, IEntity targetEntity)
        //{
        //    Console.WriteLine($"Player [{ player.Id }] { player.Name } has exploded entity ID { targetEntity.Id } at { position } of explosion type { explosionType } and explosion FX { explosionFx }.");
        //    return true;
        //}

        // ISSUE: Fails to register method
        //[ScriptEvent(ScriptEventType.Fire)]
        //public bool PlayerFireCatchedEvent(IExamplePlayerEntity player, FireInfo[] fireInfos)
        //{
        //    Console.WriteLine($"Player [{ player.Id }] { player.Name } is under fire. Infos:");
        //    foreach (FireInfo fire_info in fireInfos)
        //    {
        //        Console.WriteLine($"\tPosition: { fire_info.Position }; Weapon hash: { fire_info.WeaponHash }");
        //    }
        //    return true;
        //}

        /// <summary>
        /// Entity meta data changed event
        /// </summary>
        /// <param name="entity">Entity</param>
        /// <param name="key">Meta data key</param>
        /// <param name="value">Meta data value</param>
        [ScriptEvent(ScriptEventType.MetaDataChange)]
        public void EntityMetaDataChangedEvent(IEntity entity, string key, object value)
        {
            Console.WriteLine($"Meta data of entity ID { entity.Id } has changed. Key: \"{ key }\"; Value: \"{ value }\"");
        }

        /// <summary>
        /// Player vehicle seat changed event
        /// </summary>
        /// <param name="vehicle">Vehicle</param>
        /// <param name="player">Player</param>
        /// <param name="oldSeat">Old seat</param>
        /// <param name="newSeat">New seat</param>
        [ScriptEvent(ScriptEventType.PlayerChangeVehicleSeat)]
        public void PlayerVehicleSeatChangedEvent(IExampleVehicleEntity vehicle, IExamplePlayerEntity player, byte oldSeat, byte newSeat)
        {
            Console.WriteLine($"Player [{ player.Id }] { player.Name } changed his vehicle seat ID from { oldSeat } to { newSeat } in vehicle ID { vehicle.Id }.");
        }

        /// <summary>
        /// Player connected event
        /// </summary>
        /// <param name="player">Player</param>
        /// <param name="reason">Reason</param>
        [ScriptEvent(ScriptEventType.PlayerConnect)]
        public void PlayerConnectedEvent(IExamplePlayerEntity player, string reason)
        {
            player.SetDateTime(DateTime.Now);
            player.Model = (uint)PedModel.FreemodeMale01;
            player.Position = spawnPosition;
            player.Rotation = spawnRotation;
            Console.WriteLine($"Player [{ player.Id }] { player.Name } - { player.Ip } has connected. Reason: \"{ reason }\".");
        }

        /// <summary>
        /// Player custom event invoked event
        /// </summary>
        /// <param name="player">Player</param>
        /// <param name="eventName">Event name</param>
        /// <param name="mValueArray">Values</param>
        [ScriptEvent(ScriptEventType.PlayerCustomEvent)]
        public void PlayerCustomEventInvokedEvent(IExamplePlayerEntity player, string eventName, MValueConst[] mValueArray)
        {
            Console.WriteLine($"Player [{ player.Id }] { player.Name } has invoked a custom event named \"{ eventName }\":");
            PrintValues(mValueArray);
        }

        /// <summary>
        /// Player damage taken event
        /// </summary>
        /// <param name="player">Player</param>
        /// <param name="attacker">Attacker</param>
        /// <param name="weapon">Weapon</param>
        /// <param name="damage">Damage</param>
        [ScriptEvent(ScriptEventType.PlayerDamage)]
        public void PlayerDamageTakenEvent(IExamplePlayerEntity player, IEntity attacker, uint weapon, ushort damage)
        {
            Console.WriteLine($"Player [{ player.Id }] { player.Name } has taken damage from entity ID { attacker.Id }. Weapon ID: { weapon }; Damage: { damage }.");
        }

        /// <summary>
        /// Player died event
        /// </summary>
        /// <param name="player">Player</param>
        /// <param name="killer">Killer</param>
        /// <param name="weapon">Weapon</param>
        [ScriptEvent(ScriptEventType.PlayerDead)]
        public void PlayerDiedEvent(IExamplePlayerEntity player, IEntity killer, uint weapon)
        {
            player.Spawn(spawnPosition, 2000U);
            player.Rotation = spawnRotation;
            Console.WriteLine($"Player [{ player.Id }] { player.Name } has been killed by entity ID { killer.Id }. Weapon ID: { weapon }.");
        }

        /// <summary>
        /// Player disconnected event
        /// </summary>
        /// <param name="player">Player</param>
        /// <param name="reason">Reason</param>
        [ScriptEvent(ScriptEventType.PlayerDisconnect)]
        public void PlayerDisconnectedEvent(IExamplePlayerEntity player, string reason)
        {
            Console.WriteLine($"Player [{ player.Id }] { player.Name } - { player.Ip } has disconnected. Reason: \"{ reason }\".");
        }

        /// <summary>
        /// Player vehicle entered event
        /// </summary>
        /// <param name="vehicle">Vehicle</param>
        /// <param name="player">Player</param>
        /// <param name="seat">Seat</param>
        [ScriptEvent(ScriptEventType.PlayerEnterVehicle)]
        public void PlayerVehicleEnteredEvent(IExampleVehicleEntity vehicle, IExamplePlayerEntity player, byte seat)
        {
            Console.WriteLine($"Player [{ player.Id }] { player.Name } has entered vehicle ID { vehicle.Id }. Seat ID: { seat }.");
        }

        /// <summary>
        /// Player vehicle left event
        /// </summary>
        /// <param name="vehicle">Vehicle</param>
        /// <param name="player">Player</param>
        /// <param name="seat">Seat</param>
        [ScriptEvent(ScriptEventType.PlayerLeaveVehicle)]
        public void PlayerVehicleLeftEvent(IExampleVehicleEntity vehicle, IExamplePlayerEntity player, byte seat)
        {
            Console.WriteLine($"Player [{ player.Id }] { player.Name } has left vehicle ID { vehicle.Id }. Seat ID: { seat }.");
        }

        /// <summary>
        /// Player removed event
        /// </summary>
        /// <param name="player">Player</param>
        [ScriptEvent(ScriptEventType.PlayerRemove)]
        public void PlayerRemovedEvent(IExamplePlayerEntity player)
        {
            Console.WriteLine($"Player [{ player.Id }] { player.Name } has been removed.");
        }

        // ISSUE: Fails to register method
        //[ScriptEvent(ScriptEventType.PlayerWeaponChange)]
        //public bool PlayerWeaponChangedEvent(IExamplePlayerEntity player, uint oldWeapon, uint newWeapon)
        //{
        //    return true;
        //}

        /// <summary>
        /// Server custom event executed event
        /// </summary>
        /// <param name="eventName">Event name</param>
        /// <param name="mValueArray">Values</param>
        [ScriptEvent(ScriptEventType.ServerCustomEvent)]
        public void ServerCustomEventExecutedEvent(string eventName, MValueConst[] mValueArray)
        {
            Console.WriteLine($"Server custom event has been executed. Event name: \"{ eventName }\"");
            PrintValues(mValueArray);
        }

        // ISSUE: Expecting 2 parameters instead of one
        //[ScriptEvent(ScriptEventType.ServerEvent)]
        //public void ServerEventExecutedEvent(object[] args)
        //{
        //    Console.WriteLine("Server event has been executed. Arguments:");
        //    for (int index = 0; index < args.Length; index++)
        //    {
        //        Console.WriteLine($"Index { index }: { args[index] }");
        //    }
        //}

        // ISSUE: Fails to register method
        //[ScriptEvent(ScriptEventType.StartProjectile)]
        //public bool ProjectileStartedEvent(IExamplePlayerEntity player, Position startPosition, Position direction, uint ammoHash, uint weaponHash)
        //{
        //    return true;
        //}

        // ISSUE: Fails to register method
        //[ScriptEvent(ScriptEventType.VehicleDestroy)]
        //public void VehicleDestroyedEvent(IExampleVehicleEntity vehicle)
        //{
        //    Console.WriteLine($"Vehicle ID { vehicle.Id } has been destroyed.");
        //}

        /// <summary>
        /// Vehicle removed event
        /// </summary>
        /// <param name="vehicle">Vehicle</param>
        [ScriptEvent(ScriptEventType.VehicleRemove)]
        public void VehicleRemovedEvent(IExampleVehicleEntity vehicle)
        {
            Console.WriteLine($"Vehicle ID { vehicle.Id } has been removed.");
        }

        /// <summary>
        /// Weapon damage performed event
        /// </summary>
        /// <param name="player">Player</param>
        /// <param name="target">Target</param>
        /// <param name="weapon">Weapon</param>
        /// <param name="damage">Damage</param>
        /// <param name="shotOffset">Shot offset</param>
        /// <param name="bodyPart">Body part</param>
        /// <returns>"true" to allow weapon damage, otherwise "false"</returns>
        [ScriptEvent(ScriptEventType.WeaponDamage)]
        public bool WeaponDamagePerformedEvent(IExamplePlayerEntity player, IEntity target, uint weapon, ushort damage, Position shotOffset, BodyPart bodyPart)
        {
            Console.WriteLine($"Player [{ player.Id }] { player.Name } performed damage on entity ID { target.Id } with weapon ID { weapon }. Damage: { damage }; Body part: { bodyPart }.");
            return true;
        }
    }
}
