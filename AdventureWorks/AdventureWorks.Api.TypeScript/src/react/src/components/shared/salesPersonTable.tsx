import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import SalesPersonMapper from '../salesPerson/salesPersonMapper';
import SalesPersonViewModel from '../salesPerson/salesPersonViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import ReactTable from 'react-table';

interface SalesPersonTableComponentProps {
  businessEntityID: number;
  apiRoute: string;
  history: any;
  match: any;
}

interface SalesPersonTableComponentState {
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  filteredRecords: Array<SalesPersonViewModel>;
}

export class SalesPersonTableComponent extends React.Component<
  SalesPersonTableComponentProps,
  SalesPersonTableComponentState
> {
  state = {
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
    filteredRecords: [],
  };

  handleEditClick(e: any, row: SalesPersonViewModel) {
    this.props.history.push(ClientRoutes.SalesPersons + '/edit/' + row.id);
  }

  handleDetailClick(e: any, row: SalesPersonViewModel) {
    this.props.history.push(ClientRoutes.SalesPersons + '/' + row.id);
  }

  componentDidMount() {
    this.setState({ ...this.state, loading: true });

    axios
      .get(this.props.apiRoute, {
        headers: {
          'Content-Type': 'application/json',
        },
      })
      .then(
        resp => {
          let response = resp.data as Array<Api.SalesPersonClientResponseModel>;

          console.log(response);

          let mapper = new SalesPersonMapper();

          let salesPersons: Array<SalesPersonViewModel> = [];

          response.forEach(x => {
            salesPersons.push(mapper.mapApiResponseToViewModel(x));
          });
          this.setState({
            ...this.state,
            filteredRecords: salesPersons,
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
                Header: 'SalesPersons',
                columns: [
                  {
                    Header: 'Bonus',
                    accessor: 'bonus',
                    Cell: props => {
                      return <span>{String(props.original.bonus)}</span>;
                    },
                  },
                  {
                    Header: 'BusinessEntityID',
                    accessor: 'businessEntityID',
                    Cell: props => {
                      return (
                        <span>{String(props.original.businessEntityID)}</span>
                      );
                    },
                  },
                  {
                    Header: 'CommissionPct',
                    accessor: 'commissionPct',
                    Cell: props => {
                      return (
                        <span>{String(props.original.commissionPct)}</span>
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
                    Header: 'Rowguid',
                    accessor: 'rowguid',
                    Cell: props => {
                      return <span>{String(props.original.rowguid)}</span>;
                    },
                  },
                  {
                    Header: 'SalesLastYear',
                    accessor: 'salesLastYear',
                    Cell: props => {
                      return (
                        <span>{String(props.original.salesLastYear)}</span>
                      );
                    },
                  },
                  {
                    Header: 'SalesQuota',
                    accessor: 'salesQuota',
                    Cell: props => {
                      return <span>{String(props.original.salesQuota)}</span>;
                    },
                  },
                  {
                    Header: 'SalesYTD',
                    accessor: 'salesYTD',
                    Cell: props => {
                      return <span>{String(props.original.salesYTD)}</span>;
                    },
                  },
                  {
                    Header: 'TerritoryID',
                    accessor: 'territoryID',
                    Cell: props => {
                      return (
                        <a
                          href=""
                          onClick={e => {
                            e.preventDefault();
                            this.props.history.push(
                              ClientRoutes.SalesTerritories +
                                '/' +
                                props.original.territoryID
                            );
                          }}
                        >
                          {String(
                            props.original.territoryIDNavigation.toDisplay()
                          )}
                        </a>
                      );
                    },
                  },
                  {
                    Header: 'Actions',
                    Cell: row => (
                      <div>
                        <Button
                          type="primary"
                          onClick={(e: any) => {
                            this.handleDetailClick(
                              e,
                              row.original as SalesPersonViewModel
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
                              row.original as SalesPersonViewModel
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
    <Hash>adccd91ad30d7991ca85f51beb24169e</Hash>
</Codenesium>*/