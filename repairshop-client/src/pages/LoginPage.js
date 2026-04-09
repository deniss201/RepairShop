import { useState } from 'react';
import api from '../services/api'

function LoginPage() {
    const [email, setEmail] = useState('');
    const [password, setPassword] = useState('');

    const handleLogin = async () => {
        const response = await api.post('/User/login', { email, password });
        localStorage.setItem('token', response.data);
    };
    // return a form with inputs and a button

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

            <button onClick={handleLogin}>Login</button>

        </div>
    );
}

export default LoginPage;