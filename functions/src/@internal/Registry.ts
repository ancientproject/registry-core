import axios from "axios";
import { error } from "console";
import { parse, NuSpec } from "@rune-temp/nuspec";
import { PackageInfo, PackageBlob } from "../models";

export default class 
{
    public static async GetPackagesInfo(): Promise<PackageInfo[]> {
        const result = await axios.get("https://registry.runic.cloud/index.json");
        const pkgs = (result.data as PackageBlob).packages;
        if(result.status === 200)
            return pkgs;
        error(`Call '/registry/index.json' with status ${result.status}.`);
        throw new Error();
    }
    public static async IsExist(id: string): Promise<boolean> {
        const metadata = await this.GetPackagesInfo();
        for(const value of metadata)
        {
            if(value.id === id)
                return true;
        }
        return false;
    }
    public static async GetManifestByID(id: string): Promise<NuSpec>
    {
        const result = await axios.get(`https://registry.runic.cloud/packages/${id}/nuspec`);
        if(result.status === 200)
            return await parse(result.data);
        error(`Call '/packages/${id}/nuspec' with status ${result.status}.`);
        throw new Error();
    }
}