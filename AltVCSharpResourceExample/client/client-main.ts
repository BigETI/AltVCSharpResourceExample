import * as altVClient from "alt-client"

altVClient.on("anyResourceError", (resourceName) => {
    altVClient.logError('Error at resource "' + resourceName + '".')
})

altVClient.on("anyResourceStart", (resourceName) => {
    altVClient.log('Resource "' + resourceName + '" has started.')
})

altVClient.on("anyResourceStop", (resourceName) => {
    altVClient.log('Resource "' + resourceName + '" has stopped.')
})

altVClient.on("connectionComplete", () => {
    altVClient.log("You have been connected!")
})

altVClient.on("consoleCommand", (name, args) => {
    altVClient.log('Command "' + name + '" has been executed. Argument: "' + args + '"')
})

altVClient.on("disconnect", () => {
    altVClient.log("You have been disconnected!")
})

altVClient.on("gameEntityCreate", (entity) => {
    altVClient.log('Entity script ID "' + entity.scriptID + '" has been created.')
})

altVClient.on("gameEntityDestroy", (entity) => {
    altVClient.log('Entity script ID "' + entity.scriptID + '" has been destroyed.')
})

altVClient.on("globalMetaChange", (key, value, oldValue) => {
    altVClient.log('Global meta data has changed. Key: "' + key + '; Value: "' + value + '"; Old value: "' + oldValue + '"')
})

altVClient.on("globalSyncedMetaChange", (key, value, oldValue) => {
    altVClient.log('Globally synchronised meta data has changed. Key: "' + key + '; Value: "' + value + '"; Old value: "' + oldValue + '"')
})

altVClient.on("keydown", (key) => {
    altVClient.log("Key down: " + key)
})

altVClient.on("keyup", (key) => {
    altVClient.log("Key up: " + key)
})

altVClient.on("removeEntity", (object) => {
    altVClient.log('Entity "' + object + '" has been removed.')
})

//altVClient.on("render", () => {
//    // ...
//})

altVClient.on("resourceStart", (errored) => {
    if (errored) {
        altVClient.logError('This resource encountered errors while starting.')
    } else {
        altVClient.log('This resource has started.')
    }
})

altVClient.on("resourceStop", () => {
    altVClient.log('This resource has stopped.')
})

altVClient.on("streamSyncedMetaChange", (key, value, oldValue) => {
    altVClient.log('Stream synchronised meta data has changed. Key: "' + key + '; Value: "' + value + '"; Old value: "' + oldValue + '"')
})

altVClient.on("syncedMetaChange", (key, value, oldValue) => {
    altVClient.log('Synchronised meta data has changed. Key: "' + key + '; Value: "' + value + '"; Old value: "' + oldValue + '"')
})

altVClient.everyTick(() => {
    // ...
})
