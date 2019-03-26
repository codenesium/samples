import React, { Component, ReactElement, ReactHTMLElement } from 'react';
import axios, { AxiosError, AxiosResponse } from 'axios';
import { Redirect } from 'react-router-dom';
import * as Api from '../../api/models';
import PersonMapper from './personMapper';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import ReactTable from 'react-table';
import PersonViewModel from './personViewModel';
import 'react-table/react-table.css';
import { Form, Button, Input, Row, Col, Alert, Spin } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import * as GlobalUtilities from '../../lib/globalUtilities';

interface PersonSearchComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface PersonSearchComponentState {
  records: Array<PersonViewModel>;
  filteredRecords: Array<PersonViewModel>;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  searchValue: string;
  deleteSubmitted: boolean;
  deleteSuccess: boolean;
  deleteResponse: string;
}

export default class PersonSearchComponent extends React.Component<
  PersonSearchComponentProps,
  PersonSearchComponentState
> {
  state = {
    deleteSubmitted: false,
    deleteSuccess: false,
    deleteResponse: '',
    records: new Array<PersonViewModel>(),
    filteredRecords: new Array<PersonViewModel>(),
    searchValue: '',
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
  };

  componentDidMount() {
    this.loadRecords();
  }

  handleEditClick(e: any, row: PersonViewModel) {
    this.props.history.push(
      ClientRoutes.People + '/edit/' + row.businessEntityID
    );
  }

  handleDetailClick(e: any, row: PersonViewModel) {
    this.props.history.push(ClientRoutes.People + '/' + row.businessEntityID);
  }

  handleCreateClick(e: any) {
    this.props.history.push(ClientRoutes.People + '/create');
  }

  handleDeleteClick(e: any, row: Api.PersonClientResponseModel) {
    axios
      .delete(
        Constants.ApiEndpoint + ApiRoutes.People + '/' + row.businessEntityID,
        {
          headers: GlobalUtilities.defaultHeaders(),
        }
      )
      .then(resp => {
        this.setState({
          ...this.state,
          deleteResponse: 'Record deleted',
          deleteSuccess: true,
          deleteSubmitted: true,
        });
        this.loadRecords(this.state.searchValue);
      })
      .catch((error: AxiosError) => {
        GlobalUtilities.logError(error);
        this.setState({
          ...this.state,
          deleteResponse: 'Error deleting record',
          deleteSuccess: false,
          deleteSubmitted: true,
        });
      });
  }

  handleSearchChanged(e: React.FormEvent<HTMLInputElement>) {
    this.loadRecords(e.currentTarget.value);
  }

  loadRecords(query: string = '') {
    this.setState({ ...this.state, searchValue: query });
    let searchEndpoint =
      Constants.ApiEndpoint + ApiRoutes.People + '?limit=100';

    if (query) {
      searchEndpoint += '&query=' + query;
    }

    axios
      .get<Array<Api.PersonClientResponseModel>>(searchEndpoint, {
        headers: GlobalUtilities.defaultHeaders(),
      })
      .then(response => {
        let viewModels: Array<PersonViewModel> = [];
        let mapper = new PersonMapper();

        response.data.forEach(x => {
          viewModels.push(mapper.mapApiResponseToViewModel(x));
        });

        this.setState({
          records: viewModels,
          filteredRecords: viewModels,
          loading: false,
          loaded: true,
          errorOccurred: false,
          errorMessage: '',
        });
      })
      .catch((error: AxiosError) => {
        GlobalUtilities.logError(error);
        this.setState({
          records: new Array<PersonViewModel>(),
          filteredRecords: new Array<PersonViewModel>(),
          loading: false,
          loaded: true,
          errorOccurred: true,
          errorMessage: 'Error from API',
        });
      });
  }

  filterGrid() {}

  render() {
    if (this.state.loading) {
      return <Spin size="large" />;
    } else if (this.state.errorOccurred) {
      return <Alert message={this.state.errorMessage} type="error" />;
    } else if (this.state.loaded) {
      let errorResponse: JSX.Element = <span />;

      if (this.state.deleteSubmitted) {
        if (this.state.deleteSuccess) {
          errorResponse = (
            <Alert
              message={this.state.deleteResponse}
              type="success"
              style={{ marginBottom: '25px' }}
            />
          );
        } else {
          errorResponse = (
            <Alert
              message={this.state.deleteResponse}
              type="error"
              style={{ marginBottom: '25px' }}
            />
          );
        }
      }

      return (
        <div>
          {errorResponse}
          <Row>
            <Col span={8} />
            <Col span={8}>
              <Input
                placeholder={'Search'}
                id={'search'}
                onChange={(e: any) => {
                  this.handleSearchChanged(e);
                }}
              />
            </Col>
            <Col span={8}>
              <Button
                style={{ float: 'right' }}
                type="primary"
                onClick={(e: any) => {
                  this.handleCreateClick(e);
                }}
              >
                +
              </Button>
            </Col>
          </Row>
          <br />
          <br />
          <ReactTable
            data={this.state.filteredRecords}
            columns={[
              {
                Header: 'Person',
                columns: [
                  {
                    Header: 'Additional Contact Info',
                    accessor: 'additionalContactInfo',
                    Cell: props => {
                      return (
                        <span>
                          {String(props.original.additionalContactInfo)}
                        </span>
                      );
                    },
                  },
                  {
                    Header: 'Demographics',
                    accessor: 'demographic',
                    Cell: props => {
                      return <span>{String(props.original.demographic)}</span>;
                    },
                  },
                  {
                    Header: 'Email Promotion',
                    accessor: 'emailPromotion',
                    Cell: props => {
                      return (
                        <span>{String(props.original.emailPromotion)}</span>
                      );
                    },
                  },
                  {
                    Header: 'First Name',
                    accessor: 'firstName',
                    Cell: props => {
                      return <span>{String(props.original.firstName)}</span>;
                    },
                  },
                  {
                    Header: 'Last Name',
                    accessor: 'lastName',
                    Cell: props => {
                      return <span>{String(props.original.lastName)}</span>;
                    },
                  },
                  {
                    Header: 'Middle Name',
                    accessor: 'middleName',
                    Cell: props => {
                      return <span>{String(props.original.middleName)}</span>;
                    },
                  },
                  {
                    Header: 'Modified Date',
                    accessor: 'modifiedDate',
                    Cell: props => {
                      return <span>{String(props.original.modifiedDate)}</span>;
                    },
                  },
                  {
                    Header: 'Name Style',
                    accessor: 'nameStyle',
                    Cell: props => {
                      return <span>{String(props.original.nameStyle)}</span>;
                    },
                  },
                  {
                    Header: 'Person Type',
                    accessor: 'personType',
                    Cell: props => {
                      return <span>{String(props.original.personType)}</span>;
                    },
                  },
                  {
                    Header: 'Rowguid',
                    accessor: 'rowguid',
                    Cell: props => {
                      return <span>{String(props.original.rowguid)}</span>;
                    },
                  },
                  {
                    Header: 'Suffix',
                    accessor: 'suffix',
                    Cell: props => {
                      return <span>{String(props.original.suffix)}</span>;
                    },
                  },
                  {
                    Header: 'Title',
                    accessor: 'title',
                    Cell: props => {
                      return <span>{String(props.original.title)}</span>;
                    },
                  },
                  {
                    Header: 'Actions',
                    minWidth: 150,
                    Cell: row => (
                      <div>
                        <Button
                          type="primary"
                          onClick={(e: any) => {
                            this.handleDetailClick(
                              e,
                              row.original as PersonViewModel
                            );
                          }}
                        >
                          <i className="fas fa-search" />
                        </Button>
                        &nbsp;
                        <Button
                          type="primary"
                          onClick={(e: any) => {
                            this.handleEditClick(
                              e,
                              row.original as PersonViewModel
                            );
                          }}
                        >
                          <i className="fas fa-edit" />
                        </Button>
                        &nbsp;
                        <Button
                          type="danger"
                          onClick={(e: any) => {
                            this.handleDeleteClick(
                              e,
                              row.original as PersonViewModel
                            );
                          }}
                        >
                          <i className="far fa-trash-alt" />
                        </Button>
                      </div>
                    ),
                  },
                ],
              },
            ]}
          />
        </div>
      );
    } else {
      return null;
    }
  }
}

export const WrappedPersonSearchComponent = Form.create({
  name: 'Person Search',
})(PersonSearchComponent);


/*<Codenesium>
    <Hash>e817637f27eb0633073c1c607e8b0ee8</Hash>
</Codenesium>*/