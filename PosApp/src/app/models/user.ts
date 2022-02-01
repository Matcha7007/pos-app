export interface UserForRegister {
    userName: string;
    email?: string;
    password: string;
    phone?: number;
    tes: number;
}

export interface UserForLogin {
    userName?: any;
    password?: any;
    token?: any;
    userRole?: any;
}