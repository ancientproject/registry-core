import on from "./@internal/map";
import registry from "./@internal/Registry";
import * as express from "express";
const app = express();
process.env["DEBUG"] = "axios";
require('axios-debug-log');

app.get('/storage/@self', async (req, res) => {
    res.send(await registry.GetPackagesInfo())
});
app.get('/storage/:id', async (req, res) => {
    const id = req.params["id"] ?? "zero";
    if(id === "zero")
        return res.status(402).send(`Package with ID 'undefined' not found.`);
    if(!await registry.IsExist(id))
        return res.status(402).send(`Package with ID '${id}' not found.`);
    return res.send(await registry.GetManifestByID(id))
});


const main = express();
main.use('/api', app);

exports.main = on(main);
