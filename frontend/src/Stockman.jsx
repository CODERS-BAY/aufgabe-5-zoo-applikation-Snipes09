import {useState} from 'react';
import {Button, TextField, List, ListItem, ListItemButton, ListItemText} from '@mui/material';

export default function Stockman() {
    const [userid, setuserid] = useState('');
    const [animalid, setanimalid] = useState('');
    const [animals, setanimals] = useState([]);
    const [race, setrace] = useState('');
    const [food, setfood] = useState('');
    const [cage, setcage] = useState('');

    const fetchAllAnimalsOfEmployee = async () => {
        try {
            const requestOptions = {
                method: 'GET',
                headers: {'Content-Type': 'application/json'}
            };
            const response = await fetch(`http://localhost:5207/api/Tierpfleger/GetAllAnimalsOfEmployeeById?id=${userid}`);
            const data = await response.json();
            setanimals(data);
        } catch (err) {
            console.error(err);
        }
    };

    const updateAnimal = async () => {
        try {
            const requestOptions = {
                method: 'POST',
                headers: {'Content-Type': 'application/json'},
                body: JSON.stringify({
                    id: animalid,
                    gattung: race,
                    nahrung: food,
                    gehegeId: cage,
                    mitarbeiterId: userid
                })
            };
            const response = await fetch(`http://localhost:5207/api/Tierpfleger/UpdateAnimal`, requestOptions);
            const data = await response.json();
        } catch (err) {
            console.error(err);
        }
    };

    return (
        <>
            <div>
                <TextField
                    label="Enter Your User Id"
                    onChange={(event) => setuserid(event.target.value)}
                    value={userid}>
                </TextField>
                <Button onClick={fetchAllAnimalsOfEmployee}>Get all my Animals</Button>

                <List>
                    {animals.map((animalItem) => (
                        <ListItem key={animalItem.id}>
                            <ListItemButton>
                                <ListItemText
                                    primary={animalItem.gattung}
                                    secondary={`Nahrung: ${animalItem.nahrung}, Gehege ID: ${animalItem.gehegeId}`}
                                />
                            </ListItemButton>
                        </ListItem>
                    ))}
                </List>
            </div>

            <div>
                <TextField
                    label="ID des Tieres"
                    onChange={(event) => setanimalid(event.target.value)}
                    value={animalid}>
                </TextField>
                <TextField
                    label="Gattung des Tieres"
                    onChange={(event) => setrace(event.target.value)}
                    value={race}>
                </TextField>
                <TextField
                    label="Nahrung des Tieres"
                    onChange={(event) => setfood(event.target.value)}
                    value={food}>
                </TextField>
                <TextField
                    label="Gehege des Tieres"
                    onChange={(event) => setcage(event.target.value)}
                    value={cage}>
                </TextField>
                <TextField
                    label="Mitarbeiter ID"
                    onChange={(event) => setuserid(event.target.value)}
                    value={userid}>
                </TextField>
                <Button onClick={updateAnimal}>Update Animal</Button>
            </div>
        </>
    );
}
