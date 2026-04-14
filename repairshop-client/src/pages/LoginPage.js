import { useState } from 'react';
import api from '../services/api'
import { jwtDecode } from 'jwt-decode';
import { useNavigate } from 'react-router-dom';

function LoginPage() {
    const [email, setEmail] = useState('');
    const [password, setPassword] = useState('');

  const navigate = useNavigate();

const handleLogin = async () => {
    const response = await api.post('/User/login', { email, password });
    localStorage.setItem('token', response.data);
    const decoded = jwtDecode(response.data);
    const role = decoded["http://schemas.microsoft.com/ws/2008/06/identity/claims/role"];
    if (role === "Admin") {
        navigate('/admin');
    } else {
        navigate('/dashboard');
    }
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

            <button onClick={handleLogin}>Login</button>

        </div>
    );
}

export default LoginPage;