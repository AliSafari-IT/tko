import fetchMock from 'fetch-mock';
import { createDocument, DocumentParam } from './useFetch';



const docParam: DocumentParam = {
    documentId: 0,
    docTitle: "Title# test",
    docContent: "Content# test",
    dateCreated: Date(),
    dateModified: Date(),
    stateModelId: 1,
    typeModelId: 1,
    projectModelId: 1,
    userModelId: 1,
    docVersion: "T.0.0"
}


describe('createDocument', () => {
  it('returns ok', async () => {
fetchMock.post('https://localhost:5001/api/Documents', { ok: 'ok' });
const response = await createDocument(docParam);
    const result = await response.json()
expect(result).toEqual({ ok: "ok" });
});
});