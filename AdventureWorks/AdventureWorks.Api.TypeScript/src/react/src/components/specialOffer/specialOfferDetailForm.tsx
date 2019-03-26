import React, { Component, FormEvent } from 'react';
import axios, { AxiosError, AxiosResponse } from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import SpecialOfferMapper from './specialOfferMapper';
import SpecialOfferViewModel from './specialOfferViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import * as GlobalUtilities from '../../lib/globalUtilities';
import { SpecialOfferProductTableComponent } from '../shared/specialOfferProductTable';

interface SpecialOfferDetailComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface SpecialOfferDetailComponentState {
  model?: SpecialOfferViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

class SpecialOfferDetailComponent extends React.Component<
  SpecialOfferDetailComponentProps,
  SpecialOfferDetailComponentState
> {
  state = {
    model: new SpecialOfferViewModel(),
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
  };

  handleEditClick(e: any) {
    this.props.history.push(
      ClientRoutes.SpecialOffers + '/edit/' + this.state.model!.specialOfferID
    );
  }

  componentDidMount() {
    this.setState({ ...this.state, loading: true });

    axios
      .get<Api.SpecialOfferClientResponseModel>(
        Constants.ApiEndpoint +
          ApiRoutes.SpecialOffers +
          '/' +
          this.props.match.params.id,
        {
          headers: GlobalUtilities.defaultHeaders(),
        }
      )
      .then(response => {
        GlobalUtilities.logInfo(response);

        let mapper = new SpecialOfferMapper();

        this.setState({
          model: mapper.mapApiResponseToViewModel(response.data),
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
    } else if (this.state.loaded) {
      return (
        <div>
          <Button
            style={{ float: 'right' }}
            type="primary"
            onClick={(e: any) => {
              this.handleEditClick(e);
            }}
          >
            <i className="fas fa-edit" />
          </Button>
          <div>
            <div>
              <h3>Category</h3>
              <p>{String(this.state.model!.category)}</p>
            </div>
            <div>
              <h3>Description</h3>
              <p>{String(this.state.model!.description)}</p>
            </div>
            <div>
              <h3>Discount Pct</h3>
              <p>{String(this.state.model!.discountPct)}</p>
            </div>
            <div>
              <h3>End Date</h3>
              <p>{String(this.state.model!.endDate)}</p>
            </div>
            <div>
              <h3>Max Qty</h3>
              <p>{String(this.state.model!.maxQty)}</p>
            </div>
            <div>
              <h3>Min Qty</h3>
              <p>{String(this.state.model!.minQty)}</p>
            </div>
            <div>
              <h3>Modified Date</h3>
              <p>{String(this.state.model!.modifiedDate)}</p>
            </div>
            <div>
              <h3>Rowguid</h3>
              <p>{String(this.state.model!.rowguid)}</p>
            </div>
            <div>
              <h3>Start Date</h3>
              <p>{String(this.state.model!.startDate)}</p>
            </div>
            <div>
              <h3>Type</h3>
              <p>{String(this.state.model!.reservedType)}</p>
            </div>
          </div>
          {message}
          <div>
            <h3>SpecialOfferProducts</h3>
            <SpecialOfferProductTableComponent
              history={this.props.history}
              match={this.props.match}
              apiRoute={
                Constants.ApiEndpoint +
                ApiRoutes.SpecialOffers +
                '/' +
                this.state.model!.specialOfferID +
                '/' +
                ApiRoutes.SpecialOfferProducts
              }
            />
          </div>
        </div>
      );
    } else {
      return null;
    }
  }
}

export const WrappedSpecialOfferDetailComponent = Form.create({
  name: 'SpecialOffer Detail',
})(SpecialOfferDetailComponent);


/*<Codenesium>
    <Hash>7794a4732b3a663bb33b4d4691f1a9b9</Hash>
</Codenesium>*/