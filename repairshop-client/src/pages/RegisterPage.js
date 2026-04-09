import { useState } from 'react';
import api from '../services/api'
import { useNavigate } from 'react-router-dom';


function RegisterPage() {
    const [email, setEmail] = useState('');
    const [password, setPassword] = useState('');
    const [firstName, setFirstName] = useState('');
    const [lastName, setLastName] = useState('');
    const [phone, setPhone] = useState('');

    const navigate = useNavigate();

    const handleRegister = async () => {
        await api.post('/User/register', { email, password, firstName, lastName, phone });
        navigate('/login');
    };


    return (
        <div>
            <input
                type="email"
                placeholder='Email'
                value={email}
                onChange={(e) => setEmail(e.target.value)}
            />

            <input
                type="password"
                placeholder='Password'
                value={password}
                onChange={(e) => setPassword(e.target.value)}
            />

            <input
                type="text"
                placeholder='First Name'
                value={firstName}
                onChange={(e) => setFirstName(e.target.value)}
            />

            <input
                type="text"
                placeholder='Last Name'
                value={lastName}
                onChange={(e) => setLastName(e.target.value)}
            />

            <input
                type="tel"
                placeholder='Phone'
                value={phone}
                onChange={(e) => setPhone(e.target.value)}
            />

            <button onClick={handleRegister}>Register</button>

        </div>
    );
}

export default RegisterPage;