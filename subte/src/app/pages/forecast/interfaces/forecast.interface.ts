export interface Forecast {
    lineaCode: string
    estaciones: Estaciones[]
}

export interface Estaciones {
    stopName: string,
    arrival: Arrival,
    departure: Departure
}

export interface Arrival {
    arrivalTime: string,
    delay: string
}

export interface Departure {
    departureTime: string,
    delay: string
}