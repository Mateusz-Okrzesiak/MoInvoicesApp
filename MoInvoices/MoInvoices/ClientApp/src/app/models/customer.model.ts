
export class Customer {

    public customerID?: number;

    constructor(
        public customerName: string,
        public nip: string,
        public street: string,
        public city: string,
        public postalCode: string,
        public userID: number,
        customerID?: number) {
            this.customerID = customerID;
        }
}
