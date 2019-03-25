export class Order {
    constructor
        (
        public id?: number,
        public rent?: boolean,
        public description?: string,
        public startDate?: Date,
        public endDate?: Date,
        public carId?: number
        ) { }
}