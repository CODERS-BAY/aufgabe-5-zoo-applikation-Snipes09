import {useState} from 'react';
import {Button, TextField, List, ListItem, ListItemButton, ListItemText} from '@mui/material';

export default function Cashier() {
    const [date, setdate] = useState('');
    const [alltickets, setalltickets] = useState([]);
    const [daytickets, setdaytickets] = useState([]);
    const [daysum, setdaysum] = useState('');

    const fetchAllTickets = async () => {
        try {
            const requestOptions = {
                method: 'GET',
                headers: {'Content-Type': 'application/json'}
            };
            const response = await fetch(`http://localhost:5207/api/Kassierer/GetAllTicket`, requestOptions);
            const data = await response.json();
            setalltickets(data.tickets);
        } catch (err) {
            console.error(err);
        }
    };

    const fetchTicketsOfDay = async () => {
        try {
            const requestOptions = {
                method: 'GET',
                headers: {'Content-Type': 'application/json'}
            };
            const response = await fetch(`http://localhost:5207/api/Kassierer/GetAllTicketsOfDate?date=${date}`, requestOptions);
            const data = await response.json();
            setdaytickets(data.tickets);
            setdaysum(data.sum);
        } catch (err) {
            console.error(err);
        }
    };

    return (
        <>
            <div>
                <Button onClick={fetchAllTickets}>Get all Tickets</Button>
                <List>
                    {alltickets.map((ticket) => (
                        <ListItem key={ticket.id}>
                            <ListItemButton>
                                <ListItemText
                                    primary={ticket.id}
                                    secondary={ticket.datum ? `${ticket.verkaufsdatum}, ${ticket.preis}` : ticket.userId}
                                />
                            </ListItemButton>
                        </ListItem>
                    ))}
                </List>
            </div>

            <div>
                <TextField
                    label="yyyy-mm-ddThh:mm:ss "
                    onChange={(event) => setdate(event.target.value)}
                    value={date}
                />
                <Button onClick={fetchTicketsOfDay}>Get all Tickets of Day</Button>
                <div>
                    <TextField value={daysum}/>
                    <List>
                        {daytickets.map((ticket) => (
                            <ListItem key={ticket.id}>
                                <ListItemButton>
                                    <ListItemText
                                        primary={ticket.id}
                                        secondary={ticket.datum ? `${ticket.verkaufsdatum}, ${ticket.preis}` : ticket.userId}
                                    />
                                </ListItemButton>
                            </ListItem>
                        ))}
                    </List>
                </div>
            </div>
        </>
    );
}
