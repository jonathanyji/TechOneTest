export const ConvertApiService = {
    async _handleHttpCall(method, url, queryParams, body) {
        let queryString = '';
        if (queryParams) {
            queryString = '?' + new URLSearchParams(queryParams).toString();
        }

        const apiUrl = `http://localhost:5002/${url}${queryString}`;

        const requestOptions = {
            method: method,
            headers: {
                'Accept': '*/*',
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(body)
        };

        try {
            const response = await fetch(apiUrl, requestOptions);
            if (!response.ok) {
                throw new Error(`HTTP error! Status: ${response.status}`);
            }
            return response.text();
        } catch (error) {
            return Promise.reject(error);
        }
    },

    async convertToWordsApi(number) {
        try {
            const queryParams = { number: number };
            const res = await this._handleHttpCall('POST', 'convert', queryParams, {});
            return res;
        } catch (error) {
            return Promise.reject(error);
        }
    }
};