import React, { Component, FormEvent } from 'react';
import axios, { AxiosError, AxiosResponse } from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import StateProvinceMapper from '../stateProvince/stateProvinceMapper';
import StateProvinceViewModel from '../stateProvince/stateProvinceViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import ReactTable from 'react-table';
import * as GlobalUtilities from '../../lib/globalUtilities';

interface StateProvinceTableComponentProps {
  apiRoute: string;
  history: any;
  match: any;
}

interface StateProvinceTableComponentState {
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  filteredRecords: Array<StateProvinceViewModel>;
}

export class StateProvinceTableComponent extends React.Component<
  StateProvinceTableComponentProps,
  StateProvinceTableComponentState
> {
  state = {
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
    filteredRecords: [],
  };

  handleEditClick(e: any, row: StateProvinceViewModel) {
    this.props.history.push(
      ClientRoutes.StateProvinces + '/edit/' + row.stateProvinceID
    );
  }

  handleDetailClick(e: any, row: StateProvinceViewModel) {
    this.props.history.push(
      ClientRoutes.StateProvinces + '/' + row.stateProvinceID
    );
  }

  componentDidMount() {
    this.loadRecords();
  }

  loadRecords() {
    this.setState({ ...this.state, loading: true });

    axios
      .get<Array<Api.StateProvinceClientResponseModel>>(this.props.apiRoute, {
        headers: GlobalUtilities.defaultHeaders(),
      })
      .then(response => {
        GlobalUtilities.logInfo(response);

        let mapper = new StateProvinceMapper();

        let stateProvinces: Array<StateProvinceViewModel> = [];

        response.data.forEach(x => {
          stateProvinces.push(mapper.mapApiResponseToViewModel(x));
        });

        this.setState({
          ...this.state,
          filteredRecords: stateProvinces,
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
                Header: 'StateProvinces',
                columns: [
                  {
                    Header: 'Country Region Code',
                    accessor: 'countryRegionCode',
                    Cell: props => {
                      return (
                        <a
                          href=""
                          onClick={e => {
                            e.preventDefault();
                            this.props.history.push(
                              ClientRoutes.CountryRegions +
                                '/' +
                                props.original.countryRegionCode
                            );
                          }}
                        >
                          {String(
                            props.original.countryRegionCodeNavigation &&
                              props.original.countryRegionCodeNavigation.toDisplay()
                          )}
                        </a>
                      );
                    },
                  },
                  {
                    Header: 'Is Only State Province Flag',
                    accessor: 'isOnlyStateProvinceFlag',
                    Cell: props => {
                      return (
                        <span>
                          {String(props.original.isOnlyStateProvinceFlag)}
                        </span>
                      );
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
                    Header: 'Name',
                    accessor: 'name',
                    Cell: props => {
                      return <span>{String(props.original.name)}</span>;
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
                    Header: 'State Province Code',
                    accessor: 'stateProvinceCode',
                    Cell: props => {
                      return (
                        <span>{String(props.original.stateProvinceCode)}</span>
                      );
                    },
                  },
                  {
                    Header: 'Territory I D',
                    accessor: 'territoryID',
                    Cell: props => {
                      return <span>{String(props.original.territoryID)}</span>;
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
                              row.original as StateProvinceViewModel
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
                              row.original as StateProvinceViewModel
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
    <Hash>31f3a5de72c913032030225c80d8cd20</Hash>
</Codenesium>*/