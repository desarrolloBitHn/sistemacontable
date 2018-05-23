import { cuentacontable } from "./cuentacontable.model";

export class cuentasGroup {
    id: number;
    categoria: string;
    deleted: boolean;
    cuentas: cuentacontable[] = [];
}
