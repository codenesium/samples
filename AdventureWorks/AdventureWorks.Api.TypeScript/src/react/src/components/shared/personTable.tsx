import React, { Component, FormEvent } from 'react';
import axios, { AxiosError, AxiosResponse } from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import PersonMapper from '../person/personMapper';
import PersonViewModel from '../person/personViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import ReactTable from 'react-table';
import * as GlobalUtilities from '../../lib/globalUtilities';

interface PersonTableComponentProps {
  apiRoute: string;
  history: any;
  match: any;
}

interface PersonTableComponentState {
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  filteredRecords: Array<PersonViewModel>;
}

export class PersonTableComponent extends React.Component<
  PersonTableComponentProps,
  PersonTableComponentState
> {
  state = {
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
    filteredRecords: [],
  };

  handleEditClick(e: any, row: PersonViewModel) {
    this.props.history.push(
      ClientRoutes.People + '/edit/' + row.businessEntityID
    );
  }

  handleDetailClick(e: any, row: PersonViewModel) {
    this.props.history.push(ClientRoutes.People + '/' + row.businessEntityID);
  }

  componentDidMount() {
    this.loadRecords();
  }

  loadRecords() {
    this.setState({ ...this.state, loading: true });

    axios
      .get<Array<Api.PersonClientResponseModel>>(this.props.apiRoute, {
        headers: GlobalUtilities.defaultHeaders(),
      })
      .then(response => {
        GlobalUtilities.logInfo(response);

        let mapper = new PersonMapper();

        let people: Array<PersonViewModel> = [];

        response.data.forEach(x => {
          people.push(mapper.mapApiResponseToViewModel(x));
        });

        this.setState({
          ...this.state,
          filteredRecords: people,
          loading: false,
          loaded: true,
          errorOccurred: false,
          errorMessage: '',
        });
      })
      .catch((error: AxiosError) => {
        GlobalUtilities.logError(error);

        if (error.response && error.response.status == 422) {
          this.setState({
            ...this.state,
            errorOccurred: false,
            errorMessage: '',
          });
        } else {
          this.setState({
            ...this.state,
            errorOccurred: true,
            errorMessage: 'Error Occurred',
          });
        }
      });
  }

  render() {
    let message: JSX.Element = <div />;
    if (this.state.errorOccurred) {
      message = <Alert message={this.state.errorMessage} type="error" />;
    }

    if (this.state.loading) {
      return <Spin size="large" />;
    } else if (this.state.errorOccurred) {
      return <Alert message={this.state.errorMessage} type="error" />;
    } else if (this.state.loaded) {
      return (
        <div>
          {message}
          <ReactTable
            data={this.state.filteredRecords}
            defaultPageSize={10}
            columns={[
              {
                Header: 'People',
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


/*<Codenesium>
    <Hash>fe9805125c4f1e3ecfd44ba805623b43</Hash>
</Codenesium>*/