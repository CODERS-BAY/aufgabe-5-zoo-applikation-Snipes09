import {useState} from 'react';
import {Button, TextField, List, ListItem, ListItemButton, ListItemText} from '@mui/material';

export default function Visitor() {
    const [animalName, setAnimalName] = useState('');
    const [animals, setAnimals] = useState([]);
    const [animal, setAnimal] = useState([]);
    const [ticketBought, setTicketBought] = useState(false);


    const fetchAllAnimals = async () => {
        try {
            const response = await fetch('http://localhost:5207/api/Zoobesucher/GetAllAnimalsOfZoo');
            const data = await response.json();
            setAnimals(data);
        } catch (err) {
            console.error(err);
        }
    };

    const fetchAnimalByName = async () => {
        try {
            const response = await fetch(`http://localhost:5207/api/Zoobesucher/GetAnimalByAnimalName?name=${animalName}`);
            const data = await response.json();
            if (data && data.animal) {
                setAnimal(data.animal);
            }
        } catch (err) {
            console.error(err);
        }
    };

    const buyTicket = async () => {
        setTicketBought(true);
        try {
            const requestOptions = {
                method: 'POST',
                headers: {'Content-Type': 'application/json'}
            };
            const response = await fetch(`http://localhost:5207/api/Kassierer/TicketKaufen`, requestOptions);
            const data = await response.json();
        } catch (err) {
            setTicketBought(false);
            console.error(err);
        }
    };

    return (
        <>
            <div>
                <Button onClick={fetchAllAnimals}>Show All Animals</Button>

                <List>
                    {animals.map((animalBackend) => (
                        <ListItem key={animalBackend.id}>
                            <ListItemButton>
                                <ListItemText
                                    primary={animalBackend.gattung}
                                    secondary={`Id:${animalBackend.id}, Gattung: ${animalBackend.gattung}, Nahrung: ${animalBackend.nahrung} , Gehege: ${animalBackend.gehegeId}`}
                                />
                            </ListItemButton>
                        </ListItem>
                    ))}
                </List>
            </div>

            <div>
                <TextField
                    label="Name des Tieres"
                    onChange={(event) => setAnimalName(event.target.value)}
                    value={animalName}
                />
                <Button onClick={fetchAnimalByName}>Get Animal</Button>

                <div>
                    <TextField label="ID" value={animal.id || ''}/>
                    <TextField label="Gattung" value={animal.gattung || ''}/>
                    <TextField label="Nahrung" value={animal.nahrung || ''}/>
                    <TextField label="Gehege ID" value={animal.gehegeId || ''}/>
                </div>
            </div>

            <div>
                <Button onClick={buyTicket}>Buy Ticket</Button>
                {ticketBought ? 'Ticket gekauft!' : ''}
            </div>
        </>
    );
}
