import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import SpecialOfferMapper from './specialOfferMapper';
import SpecialOfferViewModel from './specialOfferViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
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
      .get(
        Constants.ApiEndpoint +
          ApiRoutes.SpecialOffers +
          '/' +
          this.props.match.params.id,
        {
          headers: {
            'Content-Type': 'application/json',
          },
        }
      )
      .then(
        resp => {
          let response = resp.data as Api.SpecialOfferClientResponseModel;

          console.log(response);

          let mapper = new SpecialOfferMapper();

          this.setState({
            model: mapper.mapApiResponseToViewModel(response),
            loading: false,
            loaded: true,
            errorOccurred: false,
            errorMessage: '',
          });
        },
        error => {
          console.log(error);
          this.setState({
            model: undefined,
            loading: false,
            loaded: true,
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
              <h3>DiscountPct</h3>
              <p>{String(this.state.model!.discountPct)}</p>
            </div>
            <div>
              <h3>EndDate</h3>
              <p>{String(this.state.model!.endDate)}</p>
            </div>
            <div>
              <h3>MaxQty</h3>
              <p>{String(this.state.model!.maxQty)}</p>
            </div>
            <div>
              <h3>MinQty</h3>
              <p>{String(this.state.model!.minQty)}</p>
            </div>
            <div>
              <h3>ModifiedDate</h3>
              <p>{String(this.state.model!.modifiedDate)}</p>
            </div>
            <div>
              <h3>rowguid</h3>
              <p>{String(this.state.model!.rowguid)}</p>
            </div>
            <div>
              <h3>SpecialOfferID</h3>
              <p>{String(this.state.model!.specialOfferID)}</p>
            </div>
            <div>
              <h3>StartDate</h3>
              <p>{String(this.state.model!.startDate)}</p>
            </div>
          </div>
          {message}
          <div>
            <h3>SpecialOfferProducts</h3>
            <SpecialOfferProductTableComponent
              specialOfferID={this.state.model!.specialOfferID}
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
    <Hash>221d32a8a812df9440e9bba2a16a4c12</Hash>
</Codenesium>*/