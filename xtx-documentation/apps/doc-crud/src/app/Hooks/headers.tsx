import { v4 as uuidv4 } from 'uuid';

export function GetHeader(): HeadersInit {
    return (headers());

    function headers(): HeadersInit {
        return {
            'Content-Type': 'application/json',
            'X-Request-Id': uuidv4(),
            'Authorization': `Bearer <API_TOKEN>`
        };
    }
};

export default GetHeader;