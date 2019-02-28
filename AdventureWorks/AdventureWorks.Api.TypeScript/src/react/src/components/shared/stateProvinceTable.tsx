import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import StateProvinceMapper from '../stateProvince/stateProvinceMapper';
import StateProvinceViewModel from '../stateProvince/stateProvinceViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import ReactTable from 'react-table';

interface StateProvinceTableComponentProps {
  stateProvinceID: number;
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
    this.props.history.push(ClientRoutes.StateProvinces + '/edit/' + row.id);
  }

  handleDetailClick(e: any, row: StateProvinceViewModel) {
    this.props.history.push(ClientRoutes.StateProvinces + '/' + row.id);
  }

  componentDidMount() {
    this.loadRecords();
  }

  loadRecords() {
    this.setState({ ...this.state, loading: true });

    axios
      .get(this.props.apiRoute, {
        headers: {
          'Content-Type': 'application/json',
        },
      })
      .then(
        resp => {
          let response = resp.data as Array<
            Api.StateProvinceClientResponseModel
          >;

          console.log(response);

          let mapper = new StateProvinceMapper();

          let stateProvinces: Array<StateProvinceViewModel> = [];

          response.forEach(x => {
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
        },
        error => {
          console.log(error);
          this.setState({
            ...this.state,
            loading: false,
            loaded: false,
            errorOccurred: true,
            errorMessage: 'Error from API',
          });
        }
      );
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
                    Header: 'CountryRegionCode',
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
                            props.original.countryRegionCodeNavigation.toDisplay()
                          )}
                        </a>
                      );
                    },
                  },
                  {
                    Header: 'IsOnlyStateProvinceFlag',
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
                    Header: 'ModifiedDate',
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
                    Header: 'StateProvinceCode',
                    accessor: 'stateProvinceCode',
                    Cell: props => {
                      return (
                        <span>{String(props.original.stateProvinceCode)}</span>
                      );
                    },
                  },
                  {
                    Header: 'StateProvinceID',
                    accessor: 'stateProvinceID',
                    Cell: props => {
                      return (
                        <span>{String(props.original.stateProvinceID)}</span>
                      );
                    },
                  },
                  {
                    Header: 'TerritoryID',
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
    <Hash>f0db222301e4dccca287526c5dfcb657</Hash>
</Codenesium>*/